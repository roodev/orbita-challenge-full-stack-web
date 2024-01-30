<template>
  <div class="content">
    <form @submit.prevent="submit">
      <v-text-field
        v-model="Name.value.value"
        :counter="10"
        :error-messages="Name.errorMessage.value"
        label="Nome"
      ></v-text-field>
      <v-text-field
        v-model="Email.value.value"
        :error-messages="Email.errorMessage.value"
        label="E-mail"
      ></v-text-field>
  
      <v-text-field
        v-model="RA.value.value"
        :counter="7"
        :error-messages="RA.errorMessage.value"
        label="RA"
      ></v-text-field>
      <v-text-field
        v-model="CPF.value.value"
        :counter="11"
        :error-messages="CPF.errorMessage.value"
        label="CPF"
      ></v-text-field>
  
      <v-btn class="me-4" type="submit"> Salvar </v-btn>
  
      <v-btn @click="handleReset"> Cancelar </v-btn>
    </form>
  </div>
</template>

<script setup>
import router from '@/router';
import { useField, useForm } from 'vee-validate'

const { handleSubmit, handleReset } = useForm({
  validationSchema: {
    Name(value) {
      if (value?.length >= 2) return true
      return 'O Nome precisa conter ao menos 2 caracteres.'
    },
    CPF(value) {
      if (value?.length > 10 && /[0-9-]+/.test(value)) return true
      return 'Número do CPF deve conter 11 dígitos.'
    },
    Email(value) {
      if (/^[a-z.-]+@[a-z.-]+\.[a-z]+$/i.test(value)) return true
      return 'Informe um e-mail válido'
    },
  },
})

const Name = useField('Name')
const RA = useField('RA')
const Email = useField('Email')
const CPF = useField('CPF')

const submit = handleSubmit(values => {
  alert(JSON.stringify(values, null, 2))
  addStudent(JSON.stringify(values, null, 2));
})

function addStudent(student) {

  const baseApiURL = 'https://localhost:44360';
  const url = `${baseApiURL}/Student`;

  fetch(url, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: student,
  })
  .then(response => {
    if (!response.ok) {
      throw new Error(`Erro na requisição: ${response.status} - ${response.statusText}`);
    }
    return response.json();
  })
  .then(data => {
    if (data) {
      alert("Aluno Cadastrado com Sucesso!");
      router.push('/StudentsList');
    }
  })
  .catch(error => {
    console.error("Erro ao cadastrar aluno:", error);
  });
}
</script>

<style scoped>
.content{
  width: 90%;
  min-width: 800px;
}
</style>
