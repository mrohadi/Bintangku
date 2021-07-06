import { Photo } from './photo';
import { RiwayatOrangTua } from './riwayatOrangTua';

export interface MemberAnak {
  id: number;
  namaLengkap: string;
  nik: number;
  jenisKelaminAnak: string;
  tanggalLahirAnak: Date;
  alamat: string;
  kontak: string;
  jumlahSaudara: number;
  riwayatOrangTua: RiwayatOrangTua;
  namaAyah: string;
  namaIbu: string;
  imagePath: string;
  namaNakes: string;
  nakesPhoto: Photo[];
}
