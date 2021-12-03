export interface FavoriteList
{
    favoriteListId:number;
    userId: number;
    imdbId: string;
    name: string;
    netflix: boolean;
    hulu: boolean;
    hboMax: boolean;
    disneyPlus: boolean;
    amazonVideo: boolean;
}