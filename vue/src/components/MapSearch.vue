<template>
  <div>
    <div id="search">
      <!-- <h2>Search and add a pin</h2> -->
      <label>
        <!-- <gmap-autocomplete @place_changed="setPlace"></gmap-autocomplete> -->
        <button id="refresh-button" @click="addMarkerToArray()">Refresh Pothole Markers</button>
      </label>
      <br />
    </div>
    <br />
    <gmap-map :options="{fullscreenControl: false}" :center="center" :zoom="14" style="width: 1024px;  height: 600px;">
      <!-- Here is the info window code -->
      <gmap-info-window
        :options="infoOptions"
        :position="infoWindowPos"
        :opened="infoWinOpen"
        @closeclick="infoWinOpen=false"
      >{{infoContent}}</gmap-info-window>

      <gmap-marker
        :key="i"
        v-for="(m,i) in markers"
        :position="m.position"
        :clickable="true"
        @click="toggleInfoWindow(m,i),center= m.position"
        icon="http://localhost:8080/construction.png"
      ></gmap-marker>
      <div slot="visible">
        <div
          style="bottom: 0; left: 0; background-color: #03c6fc; color: white; position: absolute; z-index: 100"
        >{{statusText}}</div>
      </div>
    </gmap-map>
  </div>
</template>

<script>
export default {
  name: "GoogleMap",
  data() {
    return {
      // change this to whatever makes sense
      center: { lat: 41.4993, lng: -81.6944 },
      markers: [],
      places: [],
      currentPlace: null,
      // This is the data for the maps window
      infoContent: "",
      infoWindowPos: null,
      infoWinOpen: false,
      currentMidx: null,
      //optional: offset infowindow so it visually sits nicely on top of our marker
      infoOptions: {
        pixelOffset: {
          width: 0,
          height: -35,
        },
      },
    };
  },
  props: {
    pothole: Array,
  },
  mounted() {
    this.geolocate();
    //Sets the function to timeout after one run
    this.interval = setTimeout(() => this.addMarkerToArray(), 1000);
  },
  created(){
  },
  methods: {
    // Js for the info window
    toggleInfoWindow: function (marker, idx) {
      this.infoWindowPos = marker.position;
      this.infoContent = marker.infoText;

      //check if its the same marker that was selected if yes toggle
      if (this.currentMidx == idx) {
        this.infoWinOpen = !this.infoWinOpen;
      }
      //if different marker set infowindow to open and reset current marker index
      else {
        this.infoWinOpen = true;
        this.currentMidx = idx;
      }
    },
    // receives a place object via the autocomplete component
    setPlace(place) {
      this.currentPlace = place;
    },
    addMarker() {
      if (this.currentPlace) {
        const marker = {
          lat: this.currentPlace.geometry.location.lat(),
          lng: this.currentPlace.geometry.location.lng(),
        };
        this.markers.push({ position: marker });
        this.places.push(this.currentPlace);
        this.center = marker;
        this.currentPlace = null;
      }
    },
    addMarkerToArray() {
      this.pothole.forEach((object) => {
        let marker = {
          lat: object.latitude,
          lng: object.longitude,
        };
        //let icon = 'https://st2.depositphotos.com/2498595/6812/v/950/depositphotos_68125511-stock-illustration-construction-works-icon-map-pin.jpg'
        this.markers.push({
          position: marker,
          infoText: object.location,
        });
        this.places.push(this.currentPlace);
        this.markers.push();
        this.center = marker;
        this.currentPlace = null;
      });
    },
    geolocate: function () {
      navigator.geolocation.getCurrentPosition((position) => {
        this.center = {
          lat: position.coords.latitude,
          lng: position.coords.longitude,
        };
      });
    },
  },
};
</script>
<style scoped>
#search{
  display: flex;
  justify-content: flex-end;
  align-items: flex-end;
}
#refresh-button{
  font-weight: bold;
}
</style>


