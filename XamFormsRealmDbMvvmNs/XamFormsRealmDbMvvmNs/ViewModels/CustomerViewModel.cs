using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Realms;
using Xamarin.Forms;
using XamFormsRealmDbMvvmNs.Models;
using XamFormsRealmDbMvvmNs.Views;

namespace XamFormsRealmDbMvvmNs.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly Realm realmInstance = Realm.GetInstance();

        private Customer customer = new Customer();

        public Customer Customer
        {
            get => customer;
            set { customer = value; OnPropertyChanged(); }
        }

        private IList<Customer> customers;

        public IList<Customer> Customers
        {
            get => customers;
            set
            {
                customers = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            Customers = realmInstance.All<Customer>().ToList();
        }

        public Command UpdateCustomer
        {
            get
            {
                return new Command(() =>
                {
                    realmInstance.Write(() => { realmInstance.Add(customer, update: true); });
                });
            }
        }

        public Command DeleteCustomer
        {
            get
            {
                return new Command(() =>
                {
                    var customerById = realmInstance.All<Customer>().First(x => x.CustomerId == customer.CustomerId);

                    using (var transaction = realmInstance.BeginWrite())
                    {
                        realmInstance.Remove(customerById);
                        transaction.Commit();
                    }
                });
            }
        }

        public Command SubmitCustomer
        {
            get
            {
                return new Command(() =>
                {
                    customer.CustomerId = realmInstance.All<Customer>().Count() + 1;

                    realmInstance.Write(() =>
                    {
                        realmInstance.Add(customer);

                        Application.Current.MainPage.DisplayAlert("Notification", "Successfully added", "Okay");
                    });
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
