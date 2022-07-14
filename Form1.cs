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

namespace Heck_V2toV3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string filename;
        public string filepath;
        public List<List<string>> mapData = new List<List<string>>();

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadDiffFile = new OpenFileDialog()
            {
                Filter = "Difficulty Files|*.dat",
                Title = "Open a Difficulty File"
            };
            if (loadDiffFile.ShowDialog() == DialogResult.OK)
            {
                filename = loadDiffFile.FileName;
                FileInfo f = new FileInfo(filename);
                filepath = f.FullName;
                fileLabel.Text = "File selected: " + filename;
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("WARNING: This program will overwrite the difficulty file you selected.\nPlease make sure you have a backup and are sure you want to move on.\n\nPress 'OK' to continue.", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Convert();
            }
        }

        private void Convert()
        {
            //Count lines
            int lines = File.ReadAllLines(filepath).Count();

            int listCount = 0;

            mapData.Clear();

            StreamReader diffFileIn = null;
            StreamWriter diffFileOut = null;

            //Copy data for one line
            try
            {
                LoadWindow readLoad = new LoadWindow("Reading file...", lines);
                readLoad.Show();

                diffFileIn = new StreamReader(filepath);
                string line = diffFileIn.ReadLine();
                while (line != null)
                {
                    List<string> data = new List<string>();

                    for (int i = 0; i < 10000; i++)
                    {
                        data.Add(line);
                        readLoad.Refresh();
                        readLoad.Bar.PerformStep();
                        readLoad.Bar.Refresh();
                        line = diffFileIn.ReadLine();
                    }

                    mapData.Add(data);
                    listCount++;
                }
                readLoad.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}. Aborting load.", "Error while loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (diffFileIn != null)
                {
                    diffFileIn.Close();
                }
            }


            //Search for Heck IDs

            LoadWindow convertLoad = new LoadWindow("Converting IDs...", lines);
            convertLoad.Show();

            for (int i = 0; i < mapData.Count(); i++)
            {
                for (int j = 0; j < mapData[i].Count(); j++)
                {
                    if (mapData[i][j] != null)
                    {
                        if (mapData[i][j].Contains("\"_color\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_color\"", "\"color\"");
                        }

                        if (mapData[i][j].Contains("\"_direction\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_direction\"", "\"direction\"");
                        }

                        if (mapData[i][j].Contains("\"_disableSpawnEffect\":true"))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_disableSpawnEffect\":true", "\"spawnEffect\":false");
                        }

                        if (mapData[i][j].Contains("\"_disableSpawnEffect\":false"))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_disableSpawnEffect\":false", "\"spawnEffect\":true");
                        }

                        if (mapData[i][j].Contains("\"_lerpType\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_lerpType\"", "\"lerpType\"");
                        }

                        if (mapData[i][j].Contains("\"_lightID\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_lightID\"", "\"lightID\"");
                        }

                        if (mapData[i][j].Contains("\"_lockPosition\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_lockPosition\"", "\"lockRotation\"");
                        }

                        if (mapData[i][j].Contains("\"_nameFilter\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_nameFilter\"", "\"nameFilter\"");
                        }

                        if (mapData[i][j].Contains("\"_preciseSpeed\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_preciseSpeed\"", "\"speed\"");
                        }

                        if (mapData[i][j].Contains("\"_prop\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_prop\"", "\"prop\"");
                        }

                        if (mapData[i][j].Contains("\"_speed\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_speed\"", "\"speed\"");
                        }

                        if (mapData[i][j].Contains("\"_step\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_step\"", "\"step\"");
                        }


                        if (mapData[i][j].Contains("\"_rotation\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_rotation\"", "\"rotation\"");
                        }

                        if (mapData[i][j].Contains("\"_environment\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_environment\"", "\"environment\"");
                        }

                        if (mapData[i][j].Contains("\"_id\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_id\"", "\"id\"");
                        }

                        if (mapData[i][j].Contains("\"_lookupMethod\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_lookupMethod\"", "\"lookupMethod\"");
                        }

                        if (mapData[i][j].Contains("\"_duplicate\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_duplicate\"", "\"duplicate\"");
                        }

                        if (mapData[i][j].Contains("\"_active\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_active\"", "\"active\"");
                        }

                        if (mapData[i][j].Contains("\"_localPosition\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_localPosition\"", "\"localPosition\"");
                        }

                        if (mapData[i][j].Contains("\"_attenuation\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_attenuation\"", "\"attenuation\"");
                        }

                        if (mapData[i][j].Contains("\"_offset\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_offset\"", "\"offset\"");
                        }

                        if (mapData[i][j].Contains("\"_startY\""))
                        {
                            mapData[i][j].Replace("\"_startY\"", "\"startY\"");
                        }

                        if (mapData[i][j].Contains("\"_height\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_height\"", "\"height\"");
                        }

                        if (mapData[i][j].Contains("\"_interactable\":false"))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_interactable\":false", "\"uninteractable\"");
                        }

                        if (mapData[i][j].Contains("\"_interactable\":true"))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_interactable\":true", "\"interactable\"");
                        }

                        if (mapData[i][j].Contains("\"_dissolve\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_dissolve\"", "\"dissolve\"");
                        }

                        if (mapData[i][j].Contains("\"_dissolveArrow\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_dissolveArrow\"", "\"dissolveArrow\"");
                        }

                        if (mapData[i][j].Contains("\"_flip\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_flip\"", "\"flip\"");
                        }

                        if (mapData[i][j].Contains("\"_disableNoteGravity\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_disableNoteGravity\"", "\"disableNoteGravity\"");
                        }

                        if (mapData[i][j].Contains("\"_noteJumpMovementSpeed\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_noteJumpMovementSpeed\"", "\"noteJumpMovementSpeed\"");
                        }

                        if (mapData[i][j].Contains("\"_disableNoteLook\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_disableNoteLook\"", "\"disableNoteLook\"");
                        }

                        if (mapData[i][j].Contains("\"_noteJumpStartBeatOffset\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_noteJumpStartBeatOffset\"", "\"noteJumpStartBeatOffset\"");
                        }

                        if (mapData[i][j].Contains("\"_time\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_time\"", "\"time\"");
                        }

                        if (mapData[i][j].Contains("\"_worldPositionStays\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_worldPositionStays\"", "\"worldPositionStays\"");
                        }

                        if (mapData[i][j].Contains("\"_parentTrack\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_parentTrack\"", "\"parentTrack\"");
                        }

                        if (mapData[i][j].Contains("\"_childrenTracks\""))
                        {
                            mapData[i][j] = mapData[i][j].Replace("\"_childrenTracks\"", "\"childrenTracks\"");
                        }
                        convertLoad.Refresh();
                        convertLoad.Bar.PerformStep();
                        convertLoad.Bar.Refresh();
                    }
                }
            }

            convertLoad.Close();

            //Replace line with new linedata
            try
            {
                LoadWindow writeLoad = new LoadWindow("Writing file...", lines);
                writeLoad.Show();
                diffFileOut = new StreamWriter(filepath);

                foreach (List<string> l in mapData)
                {
                    foreach (string s in l)
                    {
                        diffFileOut.WriteLine(s);
                        writeLoad.Refresh();
                        writeLoad.Bar.PerformStep();
                        writeLoad.Bar.Refresh();
                    }
                }
                writeLoad.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to file: {ex.Message}. Aborting save.", "Error while loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (diffFileOut != null)
                {
                    diffFileOut.Close();
                }
            }

            MessageBox.Show($"File successfully converted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
