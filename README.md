# C-Automation
This is an automation project with selenium & C# for study purpose

# Drop-Down
SelectElement selectTypeOfAppointment = new SelectElement(driver.FindElement(By.XPath("(//select[@id='appointment_type'])[1]")));
selectProjectOrDepartment.SelectByValue("Permanent");

# Multi-Select
SelectElement selectTypeOfAppointment = new SelectElement(driver.FindElement(By.XPath("(//select[@id='appointment_type'])[1]")));
selectProjectOrDepartment.SelectByValue("Permanent");
selectProjectOrDepartment.SelectByValue("Temporary");

public class SeleniumCustomMethods
{
	 public static void Multiselect(IWebDriver driver, By locator, string[] texts)
	 {
	     SelectElement multiSelect = new SelectElement(driver.FindElement(locator));

	     foreach (var item in texts)
	     {
	         multiSelect.SelectByText(item);
	     }
	 }

	 public static List<string> GetAllSelectedLists(IWebDriver driver, By locator)
	 {
	     List<string> options = new List<string>();
	     SelectElement multiSelect = new SelectElement(driver.FindElement(locator));

	     IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;

	     foreach (IWebElement option in selectedOption)
	     {
	         options.Add(option.Text);
	     }

	     return options;
	 }
}

 public class Tests
 {

	 [Test]
	public void HANDICAPJob()
	{
		    SeleniumCustomMethods.Multiselect(driver, By.XPath("(//span[@role='combobox'])[2]"), ["Business Analysis", "Disability Inclusion"]);

	    	List<string> getSelectedOptions = SeleniumCustomMethods.GetAllSelectedLists(driver, By.XPath("(//span[@role='combobox'])[2]"));

	    	foreach(var selectedOption in getSelectedOptions)
	    	{
	    		Consol.WriteLine(selectedOption);
	    	}

	    	//getSelectedOptions.ForEach(Console.WriteLine);
	}
}