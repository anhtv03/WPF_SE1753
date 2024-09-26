using AutomobileLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository {
    public interface ICarRepository {

        List<Car> GetCars();

        Car GetCarByID(int id);

        void InsertCar(Car car);

        void UpdateCar(Car car);    

        void DeleteCar(Car car);
    }
}
