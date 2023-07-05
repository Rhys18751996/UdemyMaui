﻿using Bogus;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UdemyMaui.MVVM.Models;

namespace UdemyMaui.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SqlPageViewModel
    {
        public List<Customer> Customers { get; set; }

        public Customer CurrentCustomer { get; set; }

        public ICommand AddOrUpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public SqlPageViewModel()
        {
            Refresh();
            GenerateNewCustomer();

            AddOrUpdateCommand = new Command(async () =>
            {
                App.CustomerRepo.AddOrUpdate(CurrentCustomer);
                Console.WriteLine(App.CustomerRepo.StatusMessage);
                GenerateNewCustomer();
                Refresh();
            });

            DeleteCommand = new Command(() =>
            {
                App.CustomerRepo.Delete(CurrentCustomer.Id);
                Refresh();
            });
        }

        private void GenerateNewCustomer()
        {
            CurrentCustomer = new Faker<Customer>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Address, f => f.Person.Address.Street)
                .Generate();
        }

        private void Refresh()
        {
            Customers = App.CustomerRepo.GetAll();
        }
    }
}
