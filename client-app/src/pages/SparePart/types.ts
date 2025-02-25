// Таблиця SpareParts
export interface ISparePart {
    id: number;
    name: string;
    imageUrl: string;
    categoryId: number;  
    categoryName: number;
    producerId: number;
    producerName: number;
    providerId: number;
    providerName: number;
    partNumber: string;
    description?: string;
    quantity: number;
    isStock:boolean;
    price: number;
}

export interface ISparePartPostRequest{
    name: string;
    imageUrl: string;
    categoryId: number;
    producerId: number;
    providerId: number;
    partNumber: string;
    description?: string;
    quantity: number;
    price: number;
}

export interface ISparePartPutRequest extends ISparePartPostRequest{
    id:number;
}