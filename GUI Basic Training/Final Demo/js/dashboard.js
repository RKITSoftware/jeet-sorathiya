import SiteNames from './siteNames.js';

$(document).ready(async function () {
  // Create an instance of SiteNames
  const siteNames = new SiteNames();

  // fetch data from api
  async function fetchData() {
    try {
      const response = await fetch("https://kontests.net/api/v1/all");
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      return data;
    } catch (error) {
      console.error('Fetch error:', error);
      throw error;
    }
  }

  // fetch data
  try {
    const data = await fetchData();
    const futureContestsContainer = document.getElementById("futureContestsContainer");
    const runningContestsContainer = document.getElementById("runningContestsContainer");

    let isfutureContests = false;
    let isrunningContests = false;

    // create card for each contest
    data.forEach(contest => {
      const card = document.createElement('div');
      card.className = 'card mb-3 mt-3';

      const startTime = new Date(contest.start_time); 
      const endTime = new Date(contest.end_time);

      // make image source URL based on contest.site
      const siteName = (contest.site === "CodeForces::Gym") ? "CodeForces" : contest.site;
      const logoSrc = `img/${siteName}.png`;
      // give tag of contest is running or not based on contest.status
      const status = (contest.status === "CODING") ? "Running" : "Not Running";
      // give text color accordion to status
      const statusClass = status === 'Running' ? 'text-danger' : 'text-normal';
      // make card
      card.innerHTML = `
        <div class="row no-gutters">
          <div class="col-md-4">
            <img src="${logoSrc}" alt="Site Logo" class="img-fluid">
          </div>
          <div class="col-md-8">
            <div class="card-body">
              <h5 class="card-title ${siteName}">${contest.name}</h5>
              <p class="${statusClass}">Status : ${status}</p>
              <p class="card-text">Starts: ${startTime.toLocaleString()}</p>
              <p class="card-text">Ends: ${endTime.toLocaleString()}</p>
              <a href="${contest.url}" class="btn btn-primary" target="_blank">View Contest</a>
            </div>
          </div>
        </div>
      `;

      // load cards
      if (status === "Running") {
        if (!isrunningContests) {
          isrunningContests = true;
          runningContestsContainer.innerHTML = ''; // Clear previous data
        }
        runningContestsContainer.appendChild(card);
      }
      else {
        if (!isfutureContests) {
          isfutureContests = true;
          futureContestsContainer.innerHTML = ''; // Clear previous data
        }
        futureContestsContainer.appendChild(card);
      }

      // Increment the count for the respective site name
      siteNames.incrementCount(siteName);
    });

    // Hide loading GIF and show data container
    $("#loading").hide();
    $(".filter-buttons").show();
    $("#runningContestsContainer").show();
    $("#futureContestsContainer").show();

  } 
  catch (error) {
    // Handle any errors that occur during the request
    const errorDisplay = document.getElementById("errorDisplay");
    errorDisplay.innerHTML = "Failed to fetch data from the API.";
    // Hide loading GIF
    $("#loading").hide();
    $("#errorDisplay").show();
  }

  // Update the count badges and implement filtering
  siteNames.names.forEach(name => {
    const count = siteNames.getCount(name);
    $(`#${name}-filter .badge`).text(count);
  });

  // Function to filter contests by site name
  function filterContests(siteName) {
    const contestCards = $('.card');
    const filteredCards = $.grep(contestCards, function (card) {
      const cardSiteName = $(card).find('.card-title').attr('class').split(' ')[1]; // second class is the site name
      return siteName === 'AllContest' || cardSiteName === siteName;
    });

    contestCards.hide(); // Hide all contest cards initially
    $(filteredCards).show(); // Show filtered contest cards
  }


  // Event listener for filter button clicks
  document.querySelectorAll('.filter-buttons button').forEach(button => {
    button.addEventListener('click', function () {
      const selectedSite = this.id.replace('-filter', ''); // Remove '-filter' from the button id
      filterContests(selectedSite);
    });
  });
});
