#include<stdio.h>
int main(){
    int n;
    long long fakultaet = 1;
    printf("Gib eine nicht negative ganze Zahl ein:");
    scanf("%d", &n);

    int i = 1;
    while(i <= n){
        fakultaet *= i;
        i++;
    }

    printf("Das ist die Fakultät: %lld", fakultaet);

    return 0;
}