<template>
    <div>
      <h2 class="mb-4">Person List</h2>
      <div class="row row-cols-1 row-cols-md-3 g-4">
        <div v-for="person in persons" :key="person.id" class="col">
          <div class="card h-100">
            <div class="card-body">
              <h5 class="card-title">{{ person.name }} {{ person.lastName }}</h5>
              <p class="card-text">
                <strong>Date of Birth:</strong> {{ formatDate(person.dateOfBirth) }}<br>
                <strong>Address:</strong> {{ person.address }}
              </p>
              <div class="d-flex justify-content-between">
                <router-link :to="'/edit/' + person.id" class="btn btn-primary btn-sm">Edit</router-link>
                <button @click="deletePerson(person.id)" class="btn btn-danger btn-sm">Delete</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: 'PersonList',
    data() {
      return {
        persons: []
      };
    },
    mounted() {
      this.fetchPersons();
    },
    methods: {
      async fetchPersons() {
        try {
          const response = await axios.get('/api/person');
          this.persons = response.data;
        } catch (error) {
          console.error('Error fetching persons:', error);
        }
      },
      async deletePerson(id) {
        if (confirm('Are you sure you want to delete this person?')) {
          try {
            await axios.delete(`/api/person/${id}`);
            this.persons = this.persons.filter(person => person.id !== id);
          } catch (error) {
            console.error('Error deleting person:', error);
          }
        }
      },
      formatDate(dateString) {
        return new Date(dateString).toLocaleDateString();
      }
    }
  };
  </script>