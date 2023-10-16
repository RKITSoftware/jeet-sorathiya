$(document).ready(function () {
    const taskList = $("#tasks");
    const taskInput = $("#task-input");
    const addTaskButton = $("#add-task");
    const apiUrl = "https://jsonplaceholder.typicode.com/todos";

    // fetch tasks
    function fetchTasks() {
      $.ajax({
        url: apiUrl,
        method: "GET",
        success: function (data) {
          taskList.empty();
          data.forEach(function (task) {
            const li = $("<li>").html(
              '<span>' + task.title + '</span><button class="delete" data-id="' + task.id + '">Delete</button>'
            );
            taskList.append(li);
          });
        },
        error: function (error) {
          console.error("Error fetching tasks:", error);
        },
      });
    }

    fetchTasks();

    // task deletion
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

    // adding a new task
    addTaskButton.click(function () {
      const text = taskInput.val();
      if (text) {
        const newTask = {
          title: text,
          completed: false,
        };
       console.log(`new task : ${newTask.title} will be add`);
        $.ajax({
          url: apiUrl,
          method: "POST",
          data: JSON.stringify(newTask),
          contentType: "application/json; charset=UTF-8",
          success: function (newTask) {
            const li = $("<li>").html(
              '<span>' + newTask.title + '</span><button class="delete" data-id="' + newTask.id + '">Delete</button>'
            );
            taskList.prepend(li);
            taskInput.val("");
            console.log(`new task : ${newTask.title} is now added`);

          },
          error: function (error) {
            console.error("Error adding task:", error);
          },
        });
      }
    });

    // Event listener for task deletion
    taskList.on("click", ".delete", function () {
      const id = $(this).attr("data-id");
      console.log(`id is :- ${id}`);
      deleteTask(id);
    });
  });
