<template>
  <div class="content">
    <v-container fluid>
      <v-row class="mb-2">
        <v-col>
          <v-text-field v-model="search" label="Digite sua busca" outlined dense
            class="search-student-bar"></v-text-field>
        </v-col>
        <v-col>
          <v-btn @click="registerStudent" color="primary" class="register-student-button">Cadastrar Aluno</v-btn>
        </v-col>
      </v-row>

      <v-row>
        <v-col v-for="(col, index) in columns" :key="index" class="col">
          <v-list>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title>{{ col.label }}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
            <v-list-item-group v-if="filteredStudents.length > 0">
              <v-list-item v-for="(student, itemIndex) in filteredStudents" :key="student.id"
                :class="{ 'striped': itemIndex % 2 === 0 }">
                <v-list-item-content>
                  <v-list-item-title v-if="col.key !== 'actions'">{{ student[col.key] }}</v-list-item-title>
                  <v-list-item-action v-else>
                    <v-btn class="icon-buttons" @click="editStudent(student)" icon>
                      <v-icon style="height: 8px;">mdi-pencil</v-icon>
                    </v-btn>
                    <v-btn class="icon-buttons" @click="confirmDelete(student)" icon>
                      <v-icon style="height: 8px;">mdi-delete</v-icon>
                    </v-btn>
                  </v-list-item-action>
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
            <v-alert v-else-if="filteredStudents.length === 0" outlined dense>
              Nenhum aluno encontrado
            </v-alert>
          </v-list>
        </v-col>
      </v-row>
      <v-dialog v-model="confirmDialog" max-width="400px">
        <v-card>
          <v-card-title></v-card-title>
          <v-card-text>
            Tem certeza que deseja excluir este aluno?
          </v-card-text>
          <v-card-actions>
            <v-btn @click="deleteStudent" color="error">Confirmar</v-btn>
            <v-btn @click="cancelDelete" color="primary">Cancelar</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-container>
  </div>
</template>

<script>

import { baseApiURL } from "@/global";
import axios from "axios";

export default {
  data() {
    return {
      search: '',
      columns: [
        { key: 'ra', label: 'RA' },
        { key: 'name', label: 'Nome' },
        { key: 'cpf', label: 'CPF' },
        { key: 'actions', label: 'Ações' },
      ],
      students: [

      ],
      confirmDialog: false,
      studentToDelete: null,
    };
  },
  computed: {
    filteredStudents() {
      return this.students.filter(student =>
        student.name.toLowerCase().includes(this.search.toLowerCase())
      );
    },
  },
  methods: {
    registerStudent() {
      this.$router.push('/StudentRegistration');
    },
    editStudent(student) {
      // this.$router.push(`/EditStudent/${student.id}`);
      console.log("Editar - ID:", student.id, "Dados:", student);
      this.$router.push({ name: 'EditStudent', params: { id: student.id, studentData: student } });
      
    },
    confirmDelete(student) {
      this.studentToDelete = student;
      this.confirmDialog = true;
      console.log('Excluir aluno:', student);
    },

    async deleteStudent() {
      if (this.studentToDelete) {
        const studentId = this.studentToDelete.id;
        console.log("studentToDelete", studentId);
        try {
          const response = await axios.delete(`${baseApiURL}/Student/${studentId}`);

          if (response.status === 200) {
            this.students = this.students.filter(aluno => aluno.id !== studentId);

            this.studentToDelete = null;
            this.confirmDialog = false;
          } else {
            console.error('Erro ao excluir aluno:', response.statusText);
          }
        } catch (error) {
          console.error('Erro ao excluir aluno:', error.message);
        }
      }
    },

    cancelDelete() {
      this.studentToDelete = null;
      this.confirmDialog = false;
    },
    confirmDeleteAction() {
      if (this.studentToDelete) {
        console.log('Excluir aluno:', this.studentToDelete);
        this.students = this.students.filter(aluno => aluno.id !== this.studentToDelete.id);
        this.studentToDelete = null;
        this.confirmDialog = false;
      }
    },
    loadStudents() {
      const url = `${baseApiURL}/Student/getstudents`;

      axios.get(url).then((res) => {
        this.students = res.data;
      })
    }
  },

  created() {
    this.loadStudents();
  }
};
</script>

<style scoped>
.col {
  flex: 1;
  margin-right: 10px;
}

.search-student-bar {
  flex-grow: 8;
  flex-basis: 0;
}

.register-student-button {
  flex-grow: 2;
  flex-basis: 0;
  height: 70%;
}

.icon-buttons {
  height: 30px;
  margin-right: 5px;
}

.striped {
  background-color: #E4E4E4;
}

.content {
  width: 95%;
  min-width: 800px;
}
</style>

