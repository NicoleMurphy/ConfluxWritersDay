using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ConfluxWritersDay.Web.ViewModels.Home;
using OpenMagic.DataAnnotations;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace ConfluxWritersDay.Tests.TestInfrastructure.Seleno.PageObjects
{
    public class RegistrationPage : Page<RegistrationViewModel>
    {
        public const string Url = "/registration";

        public void Submit()
        {
            this.SubmitButton.Click();
        }

        public RegistrationPage FillForm(RegistrationViewModel model)
        {
            var implementedProperties = new List<string>() { "FirstName" };

            this.FillForm<RegistrationViewModel>(model, typeof(RegistrationViewModel).GetProperties().Where(p => implementedProperties.Contains(p.Name)), new Dictionary<string, Func<RegistrationViewModel, PropertyInfo, string>>());

            return this;
        }

        private void FillForm<TModel>(TModel model)
        {
            this.FillForm(model, typeof(TModel).GetProperties(), new Dictionary<string, Func<TModel, PropertyInfo, string>>());
        }

        private void FillForm<TModel>(TModel model, IEnumerable<PropertyInfo> properties, IDictionary<string, Func<TModel, PropertyInfo, string>> valueGetters)
        {
            var pairs = from p in properties
                        let e = this.GetElement(p)
                        where e != null
                        select new { Property = p, Element = e };

            foreach (var pair in pairs)
            {
                var property = pair.Property;
                var element = pair.Element;

                element.Clear();

                var value = this.GetValue(model, property, valueGetters);

                if (value == null)
                {
                    continue;
                }

                element.SendKeys(value.ToString());
            }
        }

        private object GetValue<TModel>(TModel model, PropertyInfo property, IDictionary<string, Func<TModel, PropertyInfo, string>> valueGetters)
        {
            Func<TModel, PropertyInfo, string> valueGetter = null;

            if (valueGetters.TryGetValue(property.Name, out valueGetter))
            {
                return valueGetter(model, property);
            }

            return property.GetValue(model, null);
        }

        public IWebElement GetElement(PropertyInfo property)
        {
            var id = property.Name.ToHtmlNamingConvention();

            return this.Find.Element(By.Id(id));
        }

        private IWebElement SubmitButton { get { return this.Find.Element(By.Id("Submit")); } }

        public IWebElement GetElement(IPropertyMetadata metadata)
        {
            return this.GetElement(metadata.PropertyInfo);
        }

        public IWebElement SetElement(IPropertyMetadata metadata, object value)
        {
            var element = this.GetElement(metadata);

            element.Clear();

            if (value == null)
            {
                return element;    
            }

            element.SendKeys(value.ToString());

            return element;
        }
    }
}
