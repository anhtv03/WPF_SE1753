using AutomobileLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using AutomobileLibrary.Manager;


namespace AutomobileLibrary.Repository {
    public class CarFileRepository : ICarRepository {
        public void DeleteCar(Car car) => CarFileManagement.Instance.DeleteCar(car);

        public Car GetCarByID(int id) => CarFileManagement.Instance.GetCarByID(id);

        public List<Car> GetCars() => CarFileManagement.Instance.GetCars();

        public void InsertCar(Car car) => CarFileManagement.Instance.InsertCar(car);

        public void UpdateCar(Car car) => CarFileManagement.Instance.UpdateCar(car);
    }
}
