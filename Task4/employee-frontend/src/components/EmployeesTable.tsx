import { Button } from "@/components/ui/button";

type Props = {
    data: any[];
    onEdit: (e: any) => void;
    onDelete: (e: any) => void;
};

export default function EmployeesTable({ data, onEdit, onDelete }: Props) {
    return (
        <table className="w-full border text-sm">
            <thead className="bg-gray-100">
            <tr>
                <th className="p-2">Отдел</th>
                <th className="p-2">Ф.И.О</th>
                <th className="p-2">Дата рождения</th>
                <th className="p-2">Дата устройства</th>
                <th className="p-2">Зарплата</th>
                <th className="p-2"></th>
            </tr>
            </thead>
            <tbody>
            {data.map((e, i) => (
                <tr key={i} className="border-t">
                    <td className="p-2">{e.position}</td>
                    <td className="p-2">{e.fullName}</td>
                    <td className="p-2">{new Date(e.dateOfBirth).toLocaleDateString()}</td>
                    <td className="p-2">{new Date(e.hiredAt).toLocaleDateString()}</td>
                    <td className="p-2">{e.salary}</td>
                    <td className="p-2 flex gap-2">
                        <Button variant="ghost" onClick={() => onEdit(e)}>✏️</Button>
                        <Button variant="ghost" onClick={() => onDelete(e)}>❌</Button>
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
    );
}