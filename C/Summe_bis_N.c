#include<stdio.h>
int main(){
    int num;
    int sum = 0;
    printf("Bitte geben sie eine positive ganze Zahl ein:");
    scanf("%d", &num);
    
    for(int i = 1; i <= num; i++) {
        sum = sum + i;
    }

    printf("Die Summe ist: %d",sum);
    return 0;

}