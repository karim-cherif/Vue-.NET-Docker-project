<template>
    <div>
      <h2 class="mb-4">Edit Person</h2>
      <form @submit.prevent="updatePerson">
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
        <button type="submit" class="btn btn-primary">Update Person</button>
      </form>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: 'EditPerson',
    data() {
      return {
        person: {
          id: '',
          name: '',
          lastName: '',
          dateOfBirth: '',
          address: ''
        }
      };
    },
    mounted() {
      this.fetchPerson();
    },
    methods: {
      async fetchPerson() {
        try {
          const response = await axios.get(`/api/person/${this.$route.params.id}`);
          this.person = response.data;
          this.person.dateOfBirth = this.formatDate(this.person.dateOfBirth);
        } catch (error) {
          console.error('Error fetching person:', error);
        }
      },
      async updatePerson() {
        try {
          await axios.put(`/api/person/${this.person.id}`, {
            name: this.person.name,
            lastName: this.person.lastName,
            dateOfBirth: this.person.dateOfBirth,
            address: this.person.address
          });
          this.$router.push('/');
        } catch (error) {
          console.error('Error updating person:', error);
        }
      },
      formatDate(dateString) {
        return new Date(dateString).toISOString().split('T')[0];
      }
    }
  };
  </script>