/* UserInterface.cs
 * Author: Rod Howell
 * 
 * Edited By: Ian Flores
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ksu.Cis300.NameLookup
{
    /// <summary>
    /// A GUI for a program that looks up information on names.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The information for each name.
        /// </summary>
        private Dictionary<FrequencyAndRank> _nameInformation = new Dictionary<FrequencyAndRank>(new List<KeyValuePair<string, FrequencyAndRank>>());

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads the given input file into a dictionary.
        /// </summary>
        /// <param name="fn">The name of the file to read.</param>
        /// <returns>A dictionary whose keys are the names from the file and whose values give the frequency and 
        /// rank for each name.</returns>
        private static Dictionary<FrequencyAndRank> ReadFile(string fn)
        {
            List<KeyValuePair<string, FrequencyAndRank>> list = new List<KeyValuePair<string, FrequencyAndRank>>();
            using (StreamReader input = new StreamReader(fn))
            {
                while (!input.EndOfStream)
                {
                    string name = input.ReadLine().Trim();
                    float freq = Convert.ToSingle(input.ReadLine());
                    int rank = Convert.ToInt32(input.ReadLine());
                    list.Add(new KeyValuePair<string, FrequencyAndRank>(name, new FrequencyAndRank(freq, rank)));
                }
            }
            return new Dictionary<FrequencyAndRank>(list);
        }

        /// <summary>
        /// Handles a Click event on the "Get Statistics" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLookup_Click(object sender, EventArgs e)
        {
            string name = uxName.Text.Trim().ToUpper();
            if (_nameInformation.TryGetValue(name, out FrequencyAndRank info))
            {
                uxFrequency.Text = info.Frequency.ToString();
                uxRank.Text = info.Rank.ToString();
            }
            else
            {
                MessageBox.Show("Name not found.");
                uxFrequency.Text = "";
                uxRank.Text = "";
            }
        }

        /// <summary>
        /// Handles a Click event on the "Remove" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRemove_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles a Click event on the "Save" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSave_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event handler for the Open raw data file button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openRawDataFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _nameInformation = ReadFile(uxOpenDialog.FileName);
                    MessageBox.Show("Number of elements: " + _nameInformation.Count +  "/n" + "Secondary table length: " + _nameInformation.SecondaryHashTableLength); 
                    //AddLater:  Add the numbers to the message box
                    uxSaveHashTableToolStripMenuItem.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }



        /// <summary>
        /// The event handler for the Save Hash Table button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveHashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uxSaveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    using (FileStream output = File.Create(uxSaveDialog.FileName))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(output, _nameInformation);
                    }
                    MessageBox.Show("File written.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// The event handler for the Open Hash Table Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openHashTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(uxOpenHashTableDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    using (FileStream input = File.OpenRead(uxOpenHashTableDialog.FileName))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        _nameInformation = (Dictionary<FrequencyAndRank>) formatter.Deserialize(input);
                    }
                    MessageBox.Show("Hash table successfully read");
                    uxSaveHashTableToolStripMenuItem.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
