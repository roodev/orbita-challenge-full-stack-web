import { createRouter, createWebHistory } from 'vue-router';
import AcademicModule from '../views/AcademicModule.vue';
import StudentsList from '../views/StudentsList.vue';
import StudentRegistration from '../views/StudentRegistration.vue';
import EditStudent from '../views/EditStudent.vue';

const routes = [
  {
    path: '/',
    redirect: '/academic',
  },
  {
    path: '/academic',
    name: 'AcademicModule',
    component: AcademicModule,
    children: [
      {
        path: '/StudentsList',
        name: 'Alunos',
        component: StudentsList,
      },
      {
        path: '/StudentRegistration',
        name: 'StudentRegistration',
        component: StudentRegistration,
      },
      {
        path: '/EditStudent',
        name: 'EditStudent',
        component: EditStudent,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
