
export enum Status{
  Aware = 0,
  InProgress = 1,
  Done = 2
}

export class Address{
  id?: number;
  street?: string;
  number?: string;
  district?: string;
  city?: string;
  state?: string;

  constructor(obj: Partial<Occurrence>){
    Object.assign(this, obj);
  }
}


export class Occurrence{
  constructor(public address: Address){}
  id?: number;
  idPerson?: number;
  idAddress?: number;
  public status: number = 0;
  frequency?: number;
  image?: string;
  createdOn?: Date;
  desciption?:string;
  category?: number;
  expectedDate?: Date;
}

