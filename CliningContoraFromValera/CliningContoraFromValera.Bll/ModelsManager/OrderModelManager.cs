﻿using CliningContoraFromValera.Bll.Models;
using CliningContoraFromValera.DAL.Managers;
using CliningContoraFromValera.DAL.DTOs;

namespace CliningContoraFromValera.Bll.ModelsManager
{
    public class OrderModelManager
    {
        OrderManager _orderManager = new OrderManager();
        ClientManager _clientManager = new ClientManager();

        public List<OrderModel> GetAllOrder()
        {
            List<OrderDTO> orders = _orderManager.GetAllOrder();
            return MapperConfigStorage.GetInstance().Map<List<OrderModel>>(orders);
        }

        public List<OrderModel> GetAllEmployeesOrdersByDate(int employeeId, DateTime date)
        {
            List<OrderDTO> orders = _orderManager.GetEmployeesOrdersByEmployeeIdByDateNew(employeeId, date);
            return MapperConfigStorage.GetInstance().Map<List<OrderModel>>(orders);
        }

        public void AddOrder(OrderModel orderModel)
        {
            OrderDTO order = MapperConfigStorage.GetInstance().Map<OrderDTO>(orderModel);
            _orderManager.AddOrder(order);
        }
        public List<OrderModel> GetOrderHistoryOfTheEmployeeById(int employeeId)
        {
            List<OrderDTO> orders = _orderManager.GetOrderHistoryOfTheEmployeeById(employeeId);
            return MapperConfigStorage.GetInstance().Map<List<OrderModel>>(orders);
        }
        public List<OrderModel> GetAllOrdersByStatus(StatusType status)
        {
            List<OrderModel> allOrders = GetAllOrder();
            List<OrderModel> result = new List<OrderModel>();
            foreach (var ord in allOrders)
            {
                if(ord.Status == status)
                {
                    result.Add(ord);
                }
            }
            return result;
        }
    }
}
