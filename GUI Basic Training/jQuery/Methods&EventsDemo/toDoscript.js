$(document).ready(function() {
    // Add a new task using append
    $('#addTask').click(function() {
        addNewTask();
    });

    // Add a new task using prepend
    $('#addTaskFirst').click(function() {
        addNewTaskFirst();
    });

    // Delete a task
    $('#taskList').on('click', '.deleteTask', function() {
        $(this).parent().remove();
    });

    // Edit a task
    $('#taskList').on('click', '.editTask', function() {
        var $taskText = $(this).siblings('.taskText'); // Get the associated task text
        var updatedTask = prompt('Edit task:', $taskText.text());
    
        if (updatedTask.trim() !== "") {
            $taskText.text(updatedTask); // Update the task text
        }
        else
        {
           var updatedTask = prompt('Edit task:', $taskText.text());
        }
    });
    
    // Add New Task
    function addNewTask() {
        let newTask = $('#task').val();
        if (newTask) {
            var taskElement = '<li><span class="taskText">' + newTask + '</span> <button class="editTask">Edit</button> <button class="deleteTask">Delete</button></li>';
            $('#taskList').append((taskElement));
            $('#task').val('');
        }
    }

    // Add New Task at First
    function addNewTaskFirst() {
        let newTask = $('#task').val();
        if (newTask) {
            var taskElement = '<li><span class="taskText">' + newTask + '</span> <button class="editTask">Edit</button> <button class="deleteTask">Delete</button></li>';
            $('#taskList').prepend((taskElement));
            $('#task').val('');
        }
    }

       // Highlight on hover
       $('#taskList').on('mouseenter', 'li', function() {
        $(this).addClass('highlighted');
    });

    $('#taskList').on('mouseleave', 'li', function() {
        $(this).removeClass('highlighted');
    });
});
