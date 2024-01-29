<template>
  <form @submit.prevent="submit">
    <v-text-field
      v-model="name.value.value"
      :counter="10"
      :error-messages="name.errorMessage.value"
      label="Nome"
    ></v-text-field>
    <v-text-field
      v-model="email.value.value"
      :error-messages="email.errorMessage.value"
      label="E-mail"
    ></v-text-field>

    <v-text-field
      v-model="ra.value.value"
      :counter="7"
      :error-messages="ra.errorMessage.value"
      label="RA"
    ></v-text-field>
    <v-text-field
      v-model="cpf.value.value"
      :counter="11"
      :error-messages="cpf.errorMessage.value"
      label="CPF"
    ></v-text-field>

    <v-btn class="me-4" type="submit"> Salvar </v-btn>
    <v-btn @click="handleReset"> Cancelar </v-btn>
  </form>
</template>

<script setup>
  import { useField, useForm } from 'vee-validate'
  import { useRouter } from 'vue-router'

  const router = useRouter()

  const { handleSubmit, resetForm } = useForm({
    validationSchema: {
      name(value) {
        if (value?.length >= 2) return true

        return 'O Nome precisa conter ao menos 2 caracteres.'
      },
      cpf(value) {
        if (value?.length > 10 && /[0-9-]+/.test(value)) return true

        return 'Número do CPF deve conter 11 dígitos.'
      },
      email(value) {
        if (/^[a-z.-]+@[a-z.-]+\.[a-z]+$/i.test(value)) return true

        return 'Informe um e-mail válido'
      },
    }
  })

  const name = useField('name')
  const ra = useField('ra')
  const email = useField('email')
  const cpf = useField('cpf')

  const submit = handleSubmit(values => {
    alert(JSON.stringify(values, null, 2))
  })

  const handleReset = () => {
    resetForm() 
    router.push('../StudentsList')
  }
</script>
