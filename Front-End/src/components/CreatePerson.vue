<template>
    <div>
      <h2 class="mb-4">Create Person</h2>
      <form @submit.prevent="createPerson">
        <div class="mb-3">
          <label for="name" class="form-label">Name</label>
          <input type="text" class="form-control" id="name" v-model="person.name" required>
        </div>
        <div class="mb-3">
          <label for="lastName" class="form-label">Last Name</label>
          <input type="text" class="form-control" id="lastName" v-model="person.lastName" required>
        </div>
        <div class="mb-3">
          <label for="dateOfBirth" class="form-label">Date of Birth</label>
          <input type="date" class="form-control" id="dateOfBirth" v-model="person.dateOfBirth" required>
        </div>
        <div class="mb-3">
          <label for="address" class="form-label">Address</label>
          <input type="text" class="form-control" id="address" v-model="person.address" required>
        </div>
        <button type="submit" class="btn btn-primary">Create Person</button>
      </form>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: 'CreatePerson',
    data() {
      return {
        person: {
          name: '',
          lastName: '',
          dateOfBirth: '',
          address: ''
        }
      };
    },
    methods: {
      async createPerson() {
        try {
          await axios.post('/api/person', this.person);
          this.$router.push('/');
        } catch (error) {
          console.error('Error creating person:', error);
        }
      }
    }
  };
  </script>