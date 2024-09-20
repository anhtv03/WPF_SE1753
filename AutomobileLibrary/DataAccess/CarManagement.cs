using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess {
    public class CarManagement {

        private static CarManagement instance = null;
        private static readonly object instanceLock = new object();
        private CarManagement() { }

        public static CarManagement Instance {
            get {
                lock (instanceLock) {
                    if (instance == null) {
                        instance = new CarManagement();
                    }
                    return instance;
                }
            }
        }
        //--------------------------------------------------
        public async Task<IEnumerable<Car>> GetCarList() {
            List<Car> cars;
            try {
                using (var myStockDB = new MyStockContext()) {
                    cars = await myStockDB.Cars.ToListAsync();
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return cars;
        }
        //-------------------------------------------------
        public Car GetCarByID(int id) {
            Car car = null;
            try {
                var myStockDB = new MyStockContext();
                car = myStockDB.Cars.SingleOrDefault(x => x.CarId == id);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return car;
        }
        //-----------------------------------------------
        public void AddNew(Car car) {
            try {
                Car _car = GetCarByID(car.CarId);
                if (_car == null) {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Add(car);
                    myStockDB.SaveChanges();
                } else {
                    throw new Exception("The car is already existed.");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        //---------------------------------------------
        public void Update(Car car) {
            try {
                Car _car = GetCarByID(car.CarId);
                if (_car != null) {
                    var myStockDB = new MyStockContext();
                    myStockDB.Entry<Car>(car).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                } else {
                    throw new Exception("The car does not already existed.");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        //---------------------------------------------
        public void Remove(Car car) {
            try {
                Car _car = GetCarByID(car.CarId);
                if (_car != null) {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Remove(car);
                    myStockDB.SaveChanges();
                } else {
                    throw new Exception("The car does not already existed.");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


    }
}
