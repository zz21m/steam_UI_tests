using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SteamTests.Managers;
using SteamTests.Utilities;

namespace SteamTests.Forms
{
    public abstract class BaseForm
    {
        protected readonly By? pageMarker;
        protected BaseForm(By? pageMarker = null)
        {
            this.pageMarker = pageMarker;
        }
        public bool IsOpened()
        {
            if (pageMarker == null)
            {
                return false;
            }
            WaitUtility.WaitForElement(pageMarker);
            return true;
        }
    }
}
