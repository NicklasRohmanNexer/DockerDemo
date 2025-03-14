<template>
  <div>
    <h1>Personer</h1>
    <ul>
      <li v-for="person in persons" :key="person.personID">
        {{ person.name }} {{ person.city }} - Age: {{ person.age }}
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from "vue";
import axios from "axios";

interface PersonDto {
  personID: number;
  name: string;
  city: string;
  age: number;
}

export default defineComponent({
  name: "PersonList",
  setup() {
    const persons = ref<PersonDto[]>([]);

    const fetchPersons = async () => {
      try {
        const response = await axios.get(
          "http://localhost:23223/Person/getAllPersons"
        );
        persons.value = response.data;
      } catch (error) {
        console.error("Error fetching persons:", error);
      }
    };

    onMounted(() => {
      fetchPersons();
    });

    return {
      persons,
    };
  },
});
</script>

<style scoped>
ul {
  background-color: aquamarine;
}
li {
  background-color: aliceblue;
}
li:hover {
  background-color: burlywood;
}
</style>
