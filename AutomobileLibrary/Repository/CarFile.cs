using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;


namespace AutomobileLibrary.Repository {
    public class CarFile : ICarRepository {

        private string _filePath;

        public CarFile() {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            this._filePath = config["filePath"];
        }

        private List<Car> ReadFile() {
            if (!File.Exists(_filePath)) {
                return new List<Car>();
            }
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Car>>(json) ?? new List<Car>();
        }

        private void WriteFile(List<Car> cars) {
            string json = JsonSerializer.Serialize(cars);
            File.WriteAllText(_filePath, json);
        }

        public void DeleteCar(Car car) {
            var cars = ReadFile();
            var carDeleted = cars.FirstOrDefault(x => x.CarId == car.CarId);

            if (carDeleted != null) {
                cars.Remove(carDeleted);
                WriteFile(cars);
            }
        }

        public Car GetCarByID(int id) {
            var cars = ReadFile();
            return cars.FirstOrDefault(x => x.CarId == id);
        }

        public List<Car> GetCars() {
            var cars = ReadFile();
            return cars;
        }

        public void InsertCar(Car car) {
            var cars = ReadFile();
            cars.Add(car);
            WriteFile(cars);
        }

        public void UpdateCar(Car car) {
            var cars = ReadFile();
            var carUpdated = cars.FirstOrDefault(c => c.CarId == car.CarId);

            if (carUpdated != null) {
                carUpdated.CarId = car.CarId;
                carUpdated.CarName = car.CarName;
                carUpdated.Manufacturer = car.Manufacturer;
                carUpdated.ReleasedYear = car.ReleasedYear;
                carUpdated.Price = car.Price;

                WriteFile(cars);
            }
        }


    }
}
