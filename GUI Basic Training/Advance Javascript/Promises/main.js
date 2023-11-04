// asynchronous function fetchData
async function fetchData() {
    const fetchButton = document.getElementById('fetchData');
    fetchButton.textContent = 'Fetching data...';
    fetchButton.style.backgroundColor = "red";

    const postList = document.getElementById('postList1');
    postList.innerHTML = '';
  
    try {
      // Fetch data
      console.log("async\await :- before fetch API Call")
      const response = await fetch('https://jsonplaceholder.typicode.com/posts');
      console.log("async\await :- after fetch API Called")
      console.log(response);
  
      // Check the network response
      if (!response.ok) {
        throw new Error('Network Error');
      }
  
      // Parse the response as JSON
      console.log("async\await :- before response.json() Call")
      const data = await response.json();
      console.log("async\await :- after response.json() Call")
        console.log(data);
      // Iterate through the data and create list items for each post's title
      data.forEach(post => {
        const listItem = document.createElement('li');
        listItem.textContent = post.title;
        postList.appendChild(listItem);
      });
    } catch (error) {
      console.error('Error:', error);
    } finally {
      fetchButton.textContent = 'Fetch Data';
    fetchButton.style.backgroundColor = "";
    }
  }
  
  const fetchDataButton = document.getElementById('fetchData');
  fetchDataButton.addEventListener('click', fetchData);


  // using Promise Object
  const fetchDataButton2 = document.getElementById('fetchData2');
  const postList = document.getElementById('postList2');

fetchDataButton2.addEventListener('click', () => {
console.log("Promise Object : Before fetchDataFromAPI() Call");
  fetchDataFromAPI()
    .then(data => {
      // Clear previous data
      postList.innerHTML = '';

      // Process and display the fetched data
      data.forEach(post => {
        const listItem = document.createElement('li');
        listItem.textContent = post.title;
        postList.appendChild(listItem);
      });
    })
    .catch(error => {
      console.error('Error fetching data:', error);
    });
console.log("Promise Object : after fetchDataFromAPI() Call");
});

function fetchDataFromAPI() {
console.log("Promise Object : Inside fetchDataFromAPI()");
  return new Promise((resolve, reject) => {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then(response => {
        console.log(response);
        if (!response.ok) {
          reject('Network response was not ok');
        }
        return response.json();
      })
      .then(data => {
        console.log(data);
        resolve(data);
      })
      .catch(error => {
        reject(error);
      });
  });
}
