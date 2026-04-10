using CommunityToolkit.Mvvm.Input;
using ZooManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Model
{
    public class Animal : ViewModelBase
    {
        private string _name { get; set; }
        private string _species { get; set; }
        private int _age { get; set; }
        private double _weight { get; set; }
        private bool _isEndangered { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Species
        {
            get { return _species; }
            set
            {
                if (_species != value)
                {
                    _species = value;
                    OnPropertyChanged(nameof(Species));
                }
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }
        public bool IsEndangered
        {
            get { return _isEndangered; }
            set
            {
                if (_isEndangered != value)
                {
                    _isEndangered = value;
                    OnPropertyChanged(nameof(IsEndangered));
                }
            }
        }

        public Animal(string name, string species, int age, double weight, bool isEndangered)
        {
            _name = name;
            _species = species;
            _age = age;
            _weight = weight;
            _isEndangered = isEndangered;
        }
    }
}
