$(document).ready(function () {
  const taskList = $("#tasks");
  const taskInput = $("#task-input");
  const addTaskButton = $("#add-task");
  const apiUrl = "https://jsonplaceholder.typicode.com/todos";

  // Fetch tasks
  function fetchTasks() {
      $.get(apiUrl, function (data) {
          taskList.empty();
          data.forEach(function (task) {
              const li = $("<li>").html(
                  '<span>' + task.title + '</span><button class="delete" data-id="' + task.id + '">Delete</button>'
              );
              taskList.append(li);
          });
      })
      .fail(function (error) {
          console.error("Error fetching tasks:", error);
      });
  }

  fetchTasks();

  // Task deletion
  function deleteTask(id) {
      $.ajax({
          url: apiUrl + "/" + id,
          method: "DELETE",
          success: function () {
              const taskElement = $('[data-id="' + id + '"]');
              if (taskElement) {
                  taskElement.parent().remove();
              }
          },
          error: function (error) {
              console.error("Error deleting task:", error);
          },
      });
  }

  // Adding a new task
  addTaskButton.click(function () {
      const text = taskInput.val();
      if (text) {
          const newTask = {
              title: text,
              completed: false,
          };
          console.log(`Adding a new task: ${newTask.title}`);

          $.post(apiUrl, newTask, function (Task) {
              const li = $("<li>").html(
                  '<span>' + Task.title + '</span><button class="delete" data-id="' + Task.id + '">Delete</button>'
              );
              taskList.prepend(li);
              taskInput.val(""); // Clear the input field.
              console.log(`New task: ${Task.title} is now added`);
          })
          .done(function () {
              console.log("POST request succeeded.");
          })
          .fail(function (error) {
              console.error("Error adding task:", error);
          });
      }
  });

  taskList.on("click", ".delete", function () {
      const id = $(this).attr("data-id");
      console.log(`Deleting task with ID: ${id}`);
      deleteTask(id);
  });
});
