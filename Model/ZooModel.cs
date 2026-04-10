using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace ZooManager.Model
{
    public class ZooModel
    {
        private List<Animal> _animals;
        public List<Animal> Animals { get { return _animals; } }
        public ZooModel()
        {
            LoadFromFile("Model/animals.txt");
        }

        private void LoadFromFile(string path)
        {
            _animals = new List<Animal>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] splitted = line.Split(';');

                Animal animal = new Animal(
                    splitted[0],
                    splitted[1],
                    int.Parse(splitted[2]),
                    double.Parse(splitted[3]),
                    bool.Parse(splitted[4])
                );
                _animals.Add(animal);
            }
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
        }
    }
}
