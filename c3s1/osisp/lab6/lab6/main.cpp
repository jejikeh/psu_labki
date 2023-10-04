#include <iostream>
#include <sys/types.h>
#include <unistd.h>

void child_1(int c) {
  for (int i = 0; i < c + 1; i++) {
    auto pid = fork();
    switch (pid) {
    case -1:
      perror("fork"); /* произошла ошибка */
      exit(1); /*выход из родительского процесса*/
    case 0:
      printf(" CHILD: Это процесс-потомок!\n");
      printf(" CHILD: Мой PID -- %d , %d\n", getpid(), i);
      printf(" CHILD: PID моего родителя -- %d\n", getppid());
      printf(" CHILD: запускаю другой процесс!\n");

      if (i == 1) {
        child_1(0);
      }

      exit(0);
    }
  }
}

void child_2(int c) {
  int rv;

  for (int i = 0; i < c + 1; i++) {
    auto pid = fork();
    switch (pid) {
    case -1:
      perror("fork"); /* произошла ошибка */
      exit(1); /*выход из родительского процесса*/
    case 0:
      printf(" CHILD: Это процесс-потомок!\n");
      printf(" CHILD: Мой PID -- %d\n", getpid());
      printf(" CHILD: PID моего родителя -- %d\n", getppid());
      printf(" CHILD: Выход!\n");

      if (i == 0) {
        std::cout << "1" << std::endl;
        child_1(0);
        child_1(0);
      }
      exit(0);
    default:
      exit(0);
    }
  }
}

int main() {
  std::cout << "1: PID: " << getpid() << std::endl;
  std::cout << "1: PPID: " << getppid() << std::endl;
  std::cout << system("ls") << std::endl;

  child_1(3); // 1
  child_1(0); // 3
  child_2(2); // 4
}
