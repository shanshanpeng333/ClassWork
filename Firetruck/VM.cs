using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Firetruck
{
    class VM : INotifyPropertyChanged
    {
        #region Properties
        List<Rout> Routlist = new List<Rout>();
        const int FIRSTNODE = 1;
        int Destination = 0;

        BindingList<Rout> routs;
        public BindingList<Rout> Routs
        {
            get { return routs; }
            set { routs = value; NotifyChanged(); }
        }

        //the selected item
        Rout selectedItem;
        public Rout SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; NotifyChanged(); }
        }

        private string selectedFileName = "";
        public string SelectedFileName
        {
            get { return selectedFileName; }
            set { selectedFileName = value; NotifyChanged(); }
        }

        private BindingList<int> fireRoute = new BindingList<int>();
        public BindingList<int> FireRoute
        {
            get { return fireRoute; }
            set { fireRoute = value; NotifyChanged(); }
        }
        #endregion

        #region Logic
        //Method to select file for import
        public void SelectFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                SelectedFileName = openFileDialog.FileName;
        }

        public void ReadFile()
        {
            if (SelectedFileName == "")
            {
                MessageBox.Show("Please select a file to import!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                string[] data = File.ReadAllLines(SelectedFileName);
                //1. how to store the graph--- Adjacency list??
                //2. how to go over the graph to generate the routes
                
                for (int i = 0; i < data.Length; i++)
                {
                    var elements = data[i].Split(' ');
                    if(elements[0].Trim() != "0")
                    {
                        Routlist.Add(new Rout
                        {
                            StartNode = int.Parse(elements[0].Trim()), //trim is delete the extra space
                            EndNode = int.Parse(elements[1].Trim())
                        });
                    }
                }
                Destination = Routlist.ElementAt(0).StartNode;

                Routs = new BindingList<Rout>(Routlist);
            }
        }


        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

    }
}
