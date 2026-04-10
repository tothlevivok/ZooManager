using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Animal animal = new Animal
                {
                    Name = splitted[0],
                    Species = splitted[1],
                    Age = int.Parse(splitted[2]),
                    Weight = double.Parse(splitted[3]),
                    IsEndangered = bool.Parse(splitted[4])
                };
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
