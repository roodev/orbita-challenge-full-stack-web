 <template>
  <div class="content">
    <form @submit.prevent="submit">
      <v-text-field 
        v-model="name.value.value" 
        :error-messages="name.errorMessage" 
        label="Nome"
      ></v-text-field>
      <v-text-field 
        v-model="email.value.value" 
        :error-messages="email.errorMessage" 
        label="E-mail"
      ></v-text-field>
      <v-text-field 
        v-model="ra.value.value" 
        :error-messages="ra.errorMessage" 
        label="RA" 
        readonly
      ></v-text-field>
      <v-text-field 
        v-model="cpf.value.value" 
        :error-messages="cpf.errorMessage" 
        label="CPF" 
        readonly
      ></v-text-field>
      <v-btn class="me-4 save-button" type="submit" title="Salvar dados"> Salvar </v-btn>
      <v-btn class="me-4 cancel-button" @click="handleReset" title="Cancelar e Voltar"> Cancelar </v-btn>
    </form>
  </div>
</template>

<script setup>
import { useField, useForm } from 'vee-validate'
import { useRouter } from 'vue-router'
import { baseApiURL } from "@/global";
import axios from 'axios';
import { onMounted, ref } from 'vue';
import { useToast } from 'vue-toastification';

const router = useRouter();
const toast = useToast();
const studentId = router.currentRoute.value.params.id;
const student = ref(null);

const fetchStudentById = (studentId) => {
  const url = `${baseApiURL}/Student/getstudentbyid/${studentId}`;
  axios.get(url).then((res) => {
    student.value = res.data;
    name.value.value = res.data.name;
    email.value.value = res.data.email;
    ra.value.value = res.data.ra;
    cpf.value.value = res.data.cpf;
  });
};

const { handleSubmit, resetForm } = useForm({
  validationSchema: {
    name(value) {
      if (value?.length >= 2) return true;
      return 'O Nome precisa conter ao menos 2 caracteres.';
    },
    email(value) {
      if (/^[a-z.-]+@[a-z.-]+\.[a-z]+$/i.test(value)) return true;
      return 'Informe um e-mail válido';
    },
  }
});

const name = useField('name');
const ra = useField('ra');
const email = useField('email');
const cpf = useField('cpf');

const submit = handleSubmit(async (values) => {
  const updatedStudentData = {
    id: studentId,
    name: values.name,
    email: values.email,
    ra: values.ra,
    cpf: values.cpf
  };

  try {
    const response = await axios.put(
      `${baseApiURL}/Student`,
      updatedStudentData
    );

    if (response.status === 200) {
      toast.success('Dados do aluno atualizados com sucesso!');
      router.push('/StudentsList');
    } else {
      toast.error(`Erro ao atualizar dados do aluno: ${response.statusText}`);
    }
  } catch (error) {
    toast.error(`Erro ao enviar solicitação: ${error.message}`);
  }
});

const handleReset = () => {
  resetForm();
  router.push('../StudentsList');
};

onMounted(() => {
  fetchStudentById(studentId);
});
</script>

<style scoped>
.content {
  margin: 10px;
  padding: 20px;
  width: 50%;
  min-width: 800px;
}

.save-button {
  color: white;
  background-color: #388E3C;
}

.cancel-button {
  color: white;
  background-color: #757575;
}
</style>

