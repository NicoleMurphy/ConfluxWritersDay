using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ConfluxWritersDay.Infrastructure.Logging;
using ConfluxWritersDay.Specifications.Infrastructure;
using ConfluxWritersDay.Specifications.Website.WebElements;

namespace ConfluxWritersDay.Specifications.Pages
{
    public abstract class Page
    {
        private static readonly ILogger Log = new Logger();

        protected void InitializeWebElements(string idPrefix)
        {
            foreach (var webElementMember in GetWebElementMembers().Where(WebElementIsNull))
            {
                InitializeWebElement(webElementMember, idPrefix);
            }
        }

        private void InitializeWebElement(MemberInfo webElementMember, string idPrefix)
        {
            Log.Trace("InitializeWebElement(webElementMember: {0}, idPrefix: {1})", webElementMember.Name, idPrefix);

            var webElement = CreateWebElement(webElementMember, idPrefix);

            webElementMember.SetValue(this, webElement);
        }

        private WebElement CreateWebElement(MemberInfo webElementMember, string idPrefix)
        {
            var id = idPrefix + webElementMember.Name;
            var type = webElementMember.ValueType();
            var value = Activator.CreateInstance(type, new object[] { id });

            return (WebElement)value;
        }

        private IEnumerable<MemberInfo> GetWebElementMembers()
        {
            return GetWebElementFields().Cast<MemberInfo>().Concat(GetWebElementProperties());
        }

        private IEnumerable<FieldInfo> GetWebElementFields()
        {
            return GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Where(f => typeof(WebElement).IsAssignableFrom(f.FieldType));
        }

        private IEnumerable<PropertyInfo> GetWebElementProperties()
        {
            return GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Where(p => typeof(WebElement).IsAssignableFrom(p.PropertyType));
        }

        private bool WebElementIsNull(MemberInfo webElement)
        {
            return webElement.GetValue(this) == null;
        }
    }
}
