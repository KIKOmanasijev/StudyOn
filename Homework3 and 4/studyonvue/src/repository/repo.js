import axios from 'axios';
import store from '../store/index';

const repo = {
    fetchAllMatches() {
    // Function: get all the matches from the database.
    axios
      .get(
        `https://localhost:5001/matches/search?CurrentPage=${store.state.currentPage}&PageSize=20`,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      )
      .then((res) => {
        store.commit("setMatches", {
          matches: res.data.payload,
        });
      })
      .catch((e) => {
        console.log(e);
      });
  },
    async fetchMatchesBySport(sport) {
      // Function: filter all matches by sport
    if (sport.trim() == "") {
      repo.fetchAllMatches();
      return;
    }

    let matches;
    await axios
      .get(
        `https://localhost:5001/matches/search?CurrentPage=${store.state.currentPage}&PageSize=20&Type=${sport}`
      )
      .then((res) => {
        matches = res.data.payload;
      });

    store.commit("setMatches", {
      matches: matches,
    });
  },
    async fetchAllFields() {
      // Function: get all the fields from the database
    let courts = await axios.get(
      `http://localhost:5000/courts/search?CurrentPage=${store.state.currentPage}&PageSize=20`,
      {
        headers: {
          Authorization: `bearer ${store.state.jwt}`,
          "Access-Control-Allow-Origin": "*",
        },
      }
    );
    store.commit("getAllFields", courts.data.payload);
  },

    fetchAllMarkers() {
      // Function: get all the markers for the fields currently in the state
    let markers = store.state.fields.map((field) => {
      return {
        lat: field.lat,
        lng: field.lng,
      };
    });
    return markers;
  },
    addMatch(data) {
      // Function: Takes user input and creates a match
    let match = {
      CourtId: data.CourtId,
      MaxPlayers: parseInt(data.MaxPlayers),
      CurrentPlayers: 1,
      Type: data.Type,
      StartTime: data.StartTime,
      EndTime: data.EndTime,
    };

    const instance = axios.create({
      baseURL: "https://localhost:5001/matches",
    });

    instance.defaults.headers.common[
      "Authorization"
    ] = `bearer ${store.state.jwt}`;
    instance.defaults.headers.post["Content-Type"] = "application/json";
    instance.post("/create", JSON.stringify(match)).then(() => {
      repo.fetchAllMatches();
    });
  },
};


export default repo;