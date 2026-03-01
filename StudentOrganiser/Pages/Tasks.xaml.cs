using StudentOrganiser.Models;
namespace StudentOrganiser.Pages;

public partial class Tasks : ContentPage
{
	private List<Models.Task> tasks = new List<Models.Task>();
  public Tasks()
	{
		InitializeComponent();
	}


	public void AddTaskClick(object sender, EventArgs e)
  {
    if (string.IsNullOrEmpty(taskName.Text))
    {
      DisplayAlert("Error", "Please enter a task name.", "OK");
      return;
    }
    var newTask = new Models.Task(taskName.Text);
    tasks.Add(newTask);
  }
  public void ShowAllTasksClicked(object sender, EventArgs e)
  {
    foreach(Models.Task task in tasks)
    {
      ShowTasks.Text += $"Nazwa taska: " + task.name + "\n";

    }
  }
}