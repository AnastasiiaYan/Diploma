using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Diploma.Helpers;

public class WaitsHelper(IWebDriver driver, TimeSpan timeout)
{
    private readonly WebDriverWait _wait = new(driver, timeout);

    public IWebElement WaitForVisibilityLocatedBy(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public ReadOnlyCollection<IWebElement> WaitForAllVisibleElementsLocatedBy(By locator)
    {
        return _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
    }

    public IWebElement WaitForExists(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementExists(locator));
    }

    public bool WaitForElementInvisible(By locator)
    {
        return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
    }

    public bool WaitForElementInvisible(IWebElement webElement)
    {
        try
        {
            // Проверка, видим ли элемент
            return _wait.Until(d => !webElement.Displayed);
        }
        catch (NoSuchElementException)
        {
            // Если элемент не найден, считаем его невидимым
            return true;
        }
        catch (StaleElementReferenceException)
        {
            // Если элемент устарел, считаем его невидимым
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            throw new WebDriverTimeoutException("Элемент не стал невидимым в течение заданного времени");
        }
    }

    public bool WaitForVisibility(IWebElement element)
    {
        return _wait.Until(_ => element.Displayed);
    }

    public IWebElement FluentWaitForElement(By locator)
    {
        // Инициализация и параметризация FluentWait
        WebDriverWait fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(12))
        {
            PollingInterval = TimeSpan.FromMilliseconds(50)
        };

        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

        // Использование
        return fluentWait.Until(_ => driver.FindElement(locator));
    }
}