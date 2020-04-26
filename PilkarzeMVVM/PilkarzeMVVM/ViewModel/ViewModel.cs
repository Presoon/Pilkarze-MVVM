using PilkarzeMVVM.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PilkarzeMVVM.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        private Model.Model model { get; set; }
        private ObservableCollection<Footballer> footballers;

        public Footballer selectedFootballer { get; set; }
        public int id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public uint weight { get; set; }
        public uint height { get; set; }
        public uint age { get; set; }

        public ViewModel()
        {
            model = new Model.Model();
            footballers = new ObservableCollection<Footballer>(model.Footballers);
            onPropertyChanged(nameof(footballers));
        }


        private bool isValidString(string arg)
        {
            if (arg != "")
            {
                foreach (var item in arg)
                {
                    if (item >= 'A' && item <= 'Z') { continue; }
                    else if (item >= 'a' && item <= 'z') { continue; }
                    else { return false; }
                }
                return true;
            }
            else return false;
        }

        public ObservableCollection<Footballer> Footballers
        {
            get { return footballers; }

            set
            {
                onPropertyChanged(nameof(Footballers));
                footballers = new ObservableCollection<Footballer>(model.Footballers);
                onPropertyChanged(nameof(Footballers));
            }
        }


        private void clearForm()
        {
            firstname = null;
            surname = null;
            age = 0;
            weight = 0;
            height = 0;
            onPropertyChanged(nameof(firstname));
            onPropertyChanged(nameof(surname));
            onPropertyChanged(nameof(age));
            onPropertyChanged(nameof(weight));
            onPropertyChanged(nameof(height));
        }

        private ICommand _addCommand = null;
        public ICommand addCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(arg => {
                        model.AddFootballer(firstname, surname, age, weight, height);
                        footballers = new ObservableCollection<Footballer>(model.Footballers);
                        onPropertyChanged(nameof(footballers));
                        clearForm();
                        selectedFootballer = null;
                        onPropertyChanged(nameof(firstname));
                        onPropertyChanged(nameof(surname));
                        onPropertyChanged(nameof(age));
                        onPropertyChanged(nameof(weight));
                        onPropertyChanged(nameof(height));
                    },
                arg => firstname != null && surname != null && isValidString(firstname) && isValidString(surname));
                }
                return _addCommand;
            }
        }

        private ICommand _editCommand = null;
        public ICommand editCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(arg => {
                        model.UpdateFootballer(selectedFootballer.Id, firstname, surname, age, weight, height);
                        footballers = new ObservableCollection<Footballer>(model.Footballers);
                        onPropertyChanged(nameof(footballers));
                        clearForm();
                        selectedFootballer = null;
                    }, arg => selectedFootballer != null && isValidString(firstname) && isValidString(surname));
                }
                return _editCommand;
            }
        }

        private ICommand _deleteCommand = null;
        public ICommand deleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(arg => {
                        model.RemoveFootballer(selectedFootballer.Id);
                        footballers = new ObservableCollection<Footballer>(model.Footballers);
                        onPropertyChanged(nameof(footballers));
                        clearForm();
                        selectedFootballer = null;
                        onPropertyChanged(nameof(selectedFootballer));
                    },
                                                    arg => selectedFootballer != null);
                }
                return _deleteCommand;
            }
        }

        private ICommand _select = null;
        public ICommand Select
        {
            get
            {
                if (_select == null)
                {
                    _select = new RelayCommand(
                        arg =>
                        {
                            if (selectedFootballer != null)
                            {
                                firstname = selectedFootballer.FirstName;
                                surname = selectedFootballer.Surname;
                                weight = selectedFootballer.Weight;
                                height = selectedFootballer.Height;
                                age = selectedFootballer.Age;
                                onPropertyChanged(nameof(firstname));
                                onPropertyChanged(nameof(surname));
                                onPropertyChanged(nameof(age));
                                onPropertyChanged(nameof(weight));
                                onPropertyChanged(nameof(height));
                            }
                        },
                        arg => true
                    );
                }
                return _select;
            }

        }
    }
}
