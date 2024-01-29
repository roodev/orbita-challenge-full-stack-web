<template>
  <v-container fluid>
    <v-row class="mb-2">
      <v-col>
        <v-text-field v-model="search" label="Digite sua busca" outlined dense class="search-student-bar"></v-text-field>
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
          <v-list-item-group v-if="alunosFiltrados.length > 0">
            <v-list-item v-for="(aluno, itemIndex) in alunosFiltrados" :key="aluno.id" :class="{ 'striped': itemIndex % 2 === 0 }">
              <v-list-item-content>
                <v-list-item-title v-if="col.key !== 'actions'">{{ aluno[col.key] }}</v-list-item-title>
                <v-list-item-action v-else>
                  <v-btn class="icon-buttons" @click="editStudent(aluno)" icon>
                    <v-icon style="height: 8px;">mdi-pencil</v-icon>
                  </v-btn>
                  <v-btn class="icon-buttons" @click="confirmDelete(aluno)" icon>
                    <v-icon style="height: 8px;">mdi-delete</v-icon>
                  </v-btn>
                </v-list-item-action>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-group>
          <v-alert v-else-if="alunosFiltrados.length === 0" outlined dense>
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
          <v-btn @click="confirmDelete" color="error">Confirmar</v-btn>
          <v-btn @click="cancelDelete" color="primary">Cancelar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      search: '',
      columns: [
        { key: 'ra', label: 'RA' },
        { key: 'nome', label: 'Nome' },
        { key: 'cpf', label: 'CPF' },
        { key: 'actions', label: 'Ações' },
      ],
      alunos: [
        { id: 1, ra: '12345', nome: 'João Augusto Galassi Mantovani', cpf: '123.456.789-01' },
        { id: 2, ra: '67890', nome: 'Maria', cpf: '987.654.321-09' },
        { id: 3, ra: '67891', nome: 'César', cpf: '987.654.321-09' },
        { id: 4, ra: '67892', nome: 'Fábio', cpf: '987.654.321-09' },
        { id: 5, ra: '67893', nome: 'Carlos', cpf: '987.654.321-09' },
        { id: 6, ra: '67894', nome: 'Marta', cpf: '987.654.321-09'},
        { id: 7, ra: '67895', nome: 'Marjorie', cpf: '987.654.321-09'},
        { id: 8, ra: '67896', nome: 'Deyverson', cpf: '987.654.321-09'},
        { id: 9, ra: '67897', nome: 'Rony', cpf: '987.654.321-09' },
        { id: 10, ra: '67898', nome: 'Alex', cpf: '987.654.321-09'},
      ],
      confirmDialog: false,
      studentToDelete: null,
    };
  },
  computed: {
    alunosFiltrados() {
      return this.alunos.filter(aluno =>
        aluno.nome.toLowerCase().includes(this.search.toLowerCase())
      );
    },
  },
  methods: {
    registerStudent() {
      this.$router.push('/StudentRegistration');
    },
    editStudent(student) {
      this.$router.push(`/EditStudent/${student.id}`);
    },
    confirmDelete(student) {
      this.studentToDelete = student;
      this.confirmDialog = true;
      console.log('Excluir aluno:', student);
    },
    cancelDelete(){
      this.studentToDelete = null;
      this.confirmDialog = false;
    },
    confirmDeleteAction(){
      if(this.studentToDelete){
        console.log('Excluir aluno:', this.studentToDelete);
        this.alunos = this.alunos.filter(aluno => aluno.id !== this.studentToDelete.id);
        this.studentToDelete = null;
        this.confirmDialog = false;
      }
    }
  },
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

.icon-buttons{
  height: 30px;
  margin-right: 5px;
}

.striped {
  background-color: #E4E4E4;
}
</style>

