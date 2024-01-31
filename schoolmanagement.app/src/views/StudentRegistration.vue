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
        :error-messages="RA.errorMessage.value"
        label="RA"
        @input="validateRA"
      ></v-text-field>
      <v-text-field
        v-model="CPF.value.value"
        :error-messages="CPF.errorMessage.value"
        label="CPF"
        @input="setOnlyNumbersCPF"
      ></v-text-field>
      
      <v-btn class="me-4 save-button" type="submit" title="Salvar Aluno"> Salvar </v-btn>
      <v-btn class="me-4 clear-button" @click="handleReset" title="Limpar campos"> Limpar </v-btn>
      <v-btn class="go-back-button" @click="goBackAction" title="Voltar"> Voltar </v-btn>
    </form>
  </div>
</template>

<script setup>
import { useToast } from 'vue-toastification';
import router from '@/router';
import { useField, useForm } from 'vee-validate';
import { baseApiURL } from '@/global';

const toast = useToast();

const { handleSubmit, handleReset } = useForm({
  validationSchema: {
    Name(value) {
      if (value?.length >= 2) return true
      return 'O Nome precisa conter ao menos 2 caracteres.'
    },
    CPF(value) {
      const numericValue = value ? value.replace(/\D/g, '') : '';
      if (/^\d{11}$/.test(numericValue)) return true;
      return 'Número do CPF deve conter exatamente 11 dígitos numéricos.';
    },
    Email(value) {
      if (/^[a-z.-]+@[a-z.-]+\.[a-z]+$/i.test(value)) return true
      return 'Informe um e-mail válido'
    },
    RA(value) {
      const numericValue = value?.replace(/\D/g, '');
      if (numericValue?.length === 10) return true;
      return 'O RA deve conter exatamente 10 dígitos numéricos.';
    },
  },
})

const Name = useField('Name')
const RA = useField('RA')
const Email = useField('Email')
const CPF = useField('CPF')

const submit = handleSubmit(values => {
  addStudent(JSON.stringify(values, null, 2));
})

function addStudent(student) {

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
      toast.success('Aluno Cadastrado com Sucesso!');
      handleReset();
      router.push('/StudentRegistration');
    }
  })
  .catch(error => {
    console.error("Erro ao cadastrar aluno:", error);
    toast.error('Erro ao cadastrar aluno.');
  });
}

function setOnlyNumbersCPF(event) {
  const numericValue = event.target.value.replace(/\D/g, '');
  CPF.value.value = numericValue.slice(0, 11);
}

function validateRA() {
  RA.value.value = RA.value.value.replace(/\D/g, '').slice(0, 10);
}

function goBackAction(){
  handleReset();
  router.push('/StudentsList');
}
</script>

<style scoped>
.content{
  margin: 10px;
  padding: 20px;
  width: 50%;
  min-width: 800px;
}

.save-button{
  color: white;
  background-color: #388E3C;
}

.clear-button{
  color: white;
  background-color: #FF9800;
}

.go-back-button{
  color: white;
  background-color: #757575;

}
</style>
