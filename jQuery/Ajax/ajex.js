$(document).ready(function () {
  const taskList = $("#tasks");
  const taskInput = $("#task-input");
  const addTaskButton = $("#add-task");
  const apiUrl = "https://jsonplaceholder.typicode.com/todos";

  // fetch tasks
  function fetchTasks() {
    return new Promise(function (resolve, reject) {
      $.get(apiUrl, function (data) {
        resolve(data);
      }).fail(function (error) {
        console.error("Error fetching tasks:", error);
        reject(error);
      });
    });
  }

  // update the task list
  function updateTaskList(data) {
    taskList.empty();
    data.forEach(function (task) {
      const li = $("<li>").html(
        '<span>' + task.title + '</span><button class="delete" data-id="' + task.id + '">Delete</button>'
      );
      taskList.append(li);
    });
  }

  // Fetch tasks and handle promise
  fetchTasks()
    .then(function (data) {
      updateTaskList(data);
      console.log("Tasks fetched successfully:", data);
    })
    .catch(function (error) {
      console.error("Error in fetching tasks:", error);
    });

  // Delete a task
  function deleteTask(id, successCallback, errorCallback) {
    $.ajax({
      url: apiUrl + "/" + id,
      method: "DELETE",
      success: function () {
        const taskElement = $('[data-id="' + id + '"]');
        if (taskElement) {
          taskElement.parent().remove();
        }
        successCallback(); // Call the success callback
      },
      error: function (error) {
        console.error("Error deleting task:", error);
        errorCallback(error); // Call the error callback
      },
    });
  }

  // add a new task
  function addTask(newTask) {
    return new Promise(function (resolve, reject) {
      $.post(apiUrl, newTask, function (Task) {
        const li = $("<li>").html(
          '<span>' + Task.title + '</span><button class="delete" data-id="' + Task.id + '">Delete</button>'
        );
        taskList.prepend(li);
        taskInput.val(""); // Clear the input field.
        resolve(Task);
      })
        .done(function () {
          console.log("POST request succeeded.");
        })
        .fail(function (error) {
          console.error("Error adding task:", error);
          reject(error);
        });
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
      console.log(`Adding a new task: ${newTask.title}`);

      addTask(newTask)
        .then(function (Task) {
          console.log(`New task: ${Task.title} is now added`);
        })
        .catch(function (error) {
          console.error("Error in adding task:", error);
        });
    }
  });

  // deleting a task
  taskList.on("click", ".delete", function () {
    const id = $(this).attr("data-id");
    console.log(`Deleting task with ID: ${id}`);
  deleteTask(
    id,
    function () {
      console.log(`Task with ID ${id} deleted successfully`);
    },
    function (error) {
      console.error(`Error deleting task with ID ${id}:`, error);
    }
  );
  });
});
