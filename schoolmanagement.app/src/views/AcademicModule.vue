<template>
  <div>
    <v-app>
      <v-app-bar app class="academic-header">
        <v-img src="./image/grupoa-logo.png" class="grupo-logo" contain></v-img>
        <v-app-bar-title>{{ pageTitle }}</v-app-bar-title>
      </v-app-bar>
      <v-navigation-drawer app>
        <v-list-item to="/StudentsList">
          <v-list-item-icon>
            <v-icon>mdi-school</v-icon>
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

<script>
import { ref, watchEffect, onMounted } from 'vue';
import { useRouter } from 'vue-router';

export default {
  setup() {
    const pageTitle = ref("Módulo Acadêmico");
    const router = useRouter();

    const updatePageTitle = (route) => {
      const routeTitleMap = {
        "/StudentsList": "Lista de Alunos",
        "/StudentRegistration": "Cadastro de Alunos",
        "/academic/EditStudent": "Edição de Alunos",
      };

      pageTitle.value = routeTitleMap[route.path] || "Módulo Acadêmico";
    };

    watchEffect(() => {
      updatePageTitle(router.currentRoute.value);
    });

    onMounted(() => {
      updatePageTitle(router.currentRoute.value);
    });

    return {
      pageTitle,
    };
  },
};
</script>

<style scoped>
.academic-header {
  background-color: #E4E4E4;
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
}

.grupo-logo {
  max-height: 40px;
}
</style>
