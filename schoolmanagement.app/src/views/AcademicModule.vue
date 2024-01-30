<template>
  <div>
    <v-app>
        <v-app-bar app class="academic-header">
            <v-img src="./image/grupoa-logo.png" class="grupo-logo" contain></v-img>
            <v-app-bar-title>Consulta de Alunos</v-app-bar-title>
        </v-app-bar>
      <v-navigation-drawer app>
        <v-list-item to="/StudentsList">
          <v-list-item-icon>
            <v-icon>mdi-home</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>Alunos</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-navigation-drawer>
      <v-main>
        <router-view></router-view>
      </v-main>
    </v-app>
  </div>
</template>

<style scoped>
.academic-header{
  background-color: #E4E4E4;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
}

.grupo-logo{
  max-height:40px;
}


</style>
