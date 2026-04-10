using ZooManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace ZooManager.ViewModel
{
    public class ZooViewModel : ViewModelBase
    {
        private ZooModel _model;
        public ObservableCollection<Animal> Animals { get; set; }
        private Animal? _selectedAnimal { get; set; }
        public Animal? SelectedAnimal {
            get { return _selectedAnimal; }
            set
            {
                if (_selectedAnimal != value)
                {
                    _selectedAnimal = value;
                    OnPropertyChanged(nameof(SelectedAnimal));
                }
            }
        }

        public string AnimalCount
        {
            get
            {
                return $"Összes állat: {Animals.Count}, ebbõl veszélyeztetett: {Animals.Count(a => a.IsEndangered)}";
            }
        }

        public RelayCommand AddAnimalCommand { get; set; }

        private string _newName { get; set; }
        private string _newSpecies { get; set; }
        private int _newAge { get; set; }
        private double _newWeight { get; set; }
        private bool _newIsEndangered { get; set; }

        public string NewName
        {
            get { return _newName; }
            set
            {
                if (_newName != value)
                {
                    _newName = value;
                    OnPropertyChanged(nameof(NewName));
                }
            }
        }

        public string NewSpecies
        {
            get { return _newSpecies; }
            set
            {
                if (_newSpecies != value)
                {
                    _newSpecies = value;
                    OnPropertyChanged(nameof(NewSpecies));
                }
            }
        }

        public int NewAge
        {
            get { return _newAge; }
            set
            {
                if (_newAge != value)
                {
                    _newAge = value;
                    OnPropertyChanged(nameof(NewAge));
                }
            }
        }

        public double NewWeight
        {
            get { return _newWeight; }
            set
            {
                if (_newWeight != value)
                {
                    _newWeight = value;
                    OnPropertyChanged(nameof(NewWeight));
                }
            }
        }

        public bool NewIsEndangered
        {
            get { return _newIsEndangered; }
            set
            {
                if (_newIsEndangered != value)
                {
                    _newIsEndangered = value;
                    OnPropertyChanged(nameof(NewIsEndangered));
                }
            }
        }

        public RelayCommand RemoveAnimalCommand { get; set; }

        public ZooViewModel(ZooModel model)
        {
            _model = model;
            Animals = new ObservableCollection<Animal>(_model.Animals);
            AddAnimalCommand = new RelayCommand(() =>
            {
                Animal newAnimal = new Animal
                {
                    Name = NewName,
                    Species = NewSpecies,
                    Age = NewAge,
                    Weight = NewWeight,
                    IsEndangered = NewIsEndangered
                };
                _model.AddAnimal(newAnimal);
                Animals.Add(newAnimal);
                OnPropertyChanged(nameof(AnimalCount));
            });
            RemoveAnimalCommand = new RelayCommand(() =>
            {
                if (SelectedAnimal != null)
                {
                    _model.RemoveAnimal(SelectedAnimal);
                    Animals.Remove(SelectedAnimal);
                    SelectedAnimal = null;
                    OnPropertyChanged(nameof(AnimalCount));
                }
            });
        }
    }
}
