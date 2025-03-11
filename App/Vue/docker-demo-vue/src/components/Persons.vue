<template>
  <div>
    <h1>Personer</h1>
    <ul>
      <li v-for="person in persons" :key="person.id">
        {{ person.firstName }} {{ person.lastName }} - Age: {{ person.age }}
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from "vue";
import axios from "axios";

interface PersonDto {
  id: number;
  firstName: string;
  lastName: string;
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
        console.log("data ", response.data);
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
