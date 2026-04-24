#include<stdio.h>
int main(){
    int num;
    printf("Bitte geben Sie eine Punkte anzahl zwischen 0 und 100 ein:");
    scanf("%d", &num);
    
    if(num < 60){
        printf("Nicht Genügend!");
    }
    else if(num < 70){
        printf("Genügend");
    }
    else if(num < 80){
        printf("Befriedigend");
    }
    else if(num < 90){
        printf("Gut");
    }
    else if(num <= 100){
        printf("Sehr Gut");
    }

    return 0;
}