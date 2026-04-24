#include<stdio.h>
int main(){
    int geheim = 42;
    int rate;
    int versuche = 0;

    while(1){
        printf("Raten Sie eine Zahl: ");
        scanf("%d", &rate);
        versuche ++;

        if(rate > geheim){
            printf("Die Zahl ist zu gross\n");
        }else if(rate < geheim){
            printf("Die Zahl ist zu klein\n");
        }else if(rate == geheim){
            printf("%d ist die Richtige Zahl.", rate);
            break;
        }
    }
    return 0;
}