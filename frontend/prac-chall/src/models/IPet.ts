export interface IPet {
    OwnerID: number;
    PetName: string;
    Type: string;

  }

export class Pet implements IPet {

    constructor(
        public OwnerID: number,
        public PetName: string,
        public Type: string        ) {
            ;
        }
    }
