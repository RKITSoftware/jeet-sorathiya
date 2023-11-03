$(document).ready(function () {
  const apiUrl = "https://jsonplaceholder.typicode.com/posts";

  //#region display post
  // display post return deferred object
  function displayPosts(posts) {
    const postsContainer = $("#posts");
    postsContainer.empty(); // Clear existing posts

    const deferred = $.Deferred(); // Create a Deferred object

    // create card for each post
    posts.forEach(function (post) {
      const postCard = `
        <div class="card mb-3">
          <div class="card-body">
            <h5 class="card-title">${post.title}</h5>
            <p class="card-text">${post.body}</p>
            <button class="btn btn-primary edit-post" data-post-id="${post.id}">Edit</button>
            <button class="btn btn-danger delete-post" data-post-id="${post.id}">Delete</button>
          </div>
        </div>
      `;
      postsContainer.append(postCard); // UI update
      // hide loading gif show contest card
      $("#loading").hide();
      $(".card").show();
    });

    // Resolve the Deferred object after displaying posts
    deferred.resolve();

    console.log("displayPosts: Data displayed.");
    return deferred.promise(); // Return the promise from the Deferred object
  }

  // get post using ajax get return deferred object
  function getPosts() {
    const deferred = $.Deferred(); // Create a Deferred object
    $.get(apiUrl)
      .done(function (data) {
        deferred.resolve(data); // Resolve the Deferred with the data
        console.log("getPosts: Posts displayed.");
      })
      .fail(function (error) {
        deferred.reject(error); // Reject the Deferred with the error
        console.error("getPosts Error:", error);
      });

    return deferred.promise(); // Return the promise from the Deferred object
  }

  // get post
  getPosts()
    .then(function (data) {
      return displayPosts(data);
    })
    .then(function () {
      console.log("All posts displayed.");
    })
    .fail(function (error) {
      console.error("Error:", error);
    });
    //#endregion

  //#region create post 

  // create post using ajax post return promise
  function createPost() {
    return new Promise(function (resolve, reject) {
      const newTitle = $("#createtitle").val();
      const newBody = $("#createBody").val();
      const newComment = {
        userId: 1,
        title: newTitle,
        body: newBody,
      };

      $.post(apiUrl, newComment)
        .done(function (post) {
          // Clear the input fields
          $("#createtitle").val("");
          $("#createBody").val("");
          // Resolve the promise with the post data
          resolve(post);
        })
        .fail(function (error) {
          // Reject the promise with the error
          reject(error);
        });
    });
  }

  // click event handler for createButton
  $("#createButton").on("click", function () {
    createPost()
      .then(function (post) {
        // create postCard
        const postCard = `
          <div class="card mb-3">
            <div class="card-body">
              <h5 class="card-title">${post.title}</h5>
              <p class="card-text">${post.body}</p>
              <button class="btn btn-primary edit-post" data-post-id="${post.id}">Edit</button>
              <button class="btn btn-danger delete-post" data-post-id="${post.id}">Delete</button>
            </div>
          </div>
        `;
        const postsContainer = $("#posts");
        postsContainer.prepend(postCard);
        console.log("New post created and displayed.");
      })
      .catch(function (error) {
        console.error("Error:", error);
      });
  });

  //#endregion 

  //#region delete post
  // click event handler for .delete-post class
  $(document).on("click", ".delete-post", function () {
    console.log("delete-post click");
    const id = $(this).attr("data-post-id");

    $.ajax({
      url: `${apiUrl}/${id}`,
      type: "DELETE",
      success: function () {
        const Element = $('[data-post-id="' + id + '"]');
        if (Element) {
          Element.closest(".card").remove();
          console.log("Post deleted.");
        }
      },
      error: function (error) {
        console.error("delete-post click Error:", error);
      }
    });
  });
  //#endregion

  //#region  update post
  // update post return promise
  function updatePost(postId, postCard) {
    return new Promise(function (resolve, reject) {
      // Get the existing post text
      const oldTitle = postCard.find(".card-title").text();
      const oldBody = postCard.find(".card-text").text();

      console.log("Existing post text retrieved - Title: " + oldTitle + ", Body: " + oldBody);

      // Prompt the user for the edited post data with default values
      const editedposttitle = prompt("Edit title:", oldTitle);
      const editedpostBody = prompt("Edit Body:", oldBody);

      if (editedposttitle !== null && editedpostBody !== null) {
        $.ajax({
          url: `${apiUrl}/${postId}`,
          type: "PUT",
          contentType: "application/json",
          data: JSON.stringify({ editedposttitle, editedpostBody }),
          success: function (data) {
            console.log("Post updated successfully.", data);
            postCard.find(".card-title").text(data.editedposttitle);
            postCard.find(".card-text").text(data.editedpostBody);

            // Resolve the promise with the updated data
            resolve(data);
          },
          error: function (error) {
            // Reject the promise with the error
            reject(error);
          }
        });
      }
    });
  }

   // click event handler for .edit-post class
  $(document).on("click", ".edit-post", async function () {
    const postId = $(this).data("post-id");
    const postCard = $(this).closest(".card");

    try {
      const updatedData = await updatePost(postId, postCard);
      console.log("edit-post click: Post updated successfully.", updatedData);
    } catch (error) {
      console.error("edit-post click Error:", error);
    }
  });
  //#endregion

});
