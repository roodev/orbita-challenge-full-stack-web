<template>
  <div>
    <v-row class="mb-2">
      <v-col>
        <img src="./grupoa-logo.png" alt="Logotipo" class="logo" />
      </v-col>
      <v-col>
        <v-list-item>
          <v-list-item-content>
            <v-list-item-title class="headline">Módulo Acadêmico</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-col>
    </v-row>

    <v-app>
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
  .logo {
    position: absolute;
    top: 10px;
    left: 10px;
    width: 100px;
    height: auto;
  }
</style>
